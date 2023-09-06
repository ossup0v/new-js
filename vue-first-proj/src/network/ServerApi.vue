<template>
    <p>Test</p>
    <button @click="sendStringg">Click me!</button>
</template>

<script>

export default {
    methods: {
        sendStringg() {
            // Usage:
            const serverApi = ServerApi.getInstance();

            // Send a string to a specific path
            const path = 'post-string'; // Change this to your desired path
            const myString = 'Hello, this is a test string!';

            serverApi.sendString(path, myString)
                .then(data => {
                    // Handle the response data here
                    console.log(data);
                })
                .catch(error => {
                    // Handle any errors that occurred during the request
                    console.error('Request error:', error);
                });
        }
    }
}
class ServerApi {
    constructor() {
        this.baseUrl = 'http://localhost:8081'; // Change this to your server's base URL
    }


    sendString(path, myString) {
        const url = `${ServerApi.instance.baseUrl}/${path}`;

        const requestData = {
            str: myString,
        };

        console.log(JSON.stringify(requestData))
        console.log(myString)

        return fetch(url, {
            method: 'POST',
            headers: {
                'accept': 'text/plain',
                'Content-Type': 'application/json',
            },
            body: myString,
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok' + response);
                }
                return response.text(); // or response.json() if the server responds with JSON
            })
            .catch(error => {
                throw error;
            });
    }

    static getInstance() {
        if (!ServerApi.instance) {
            ServerApi.instance = new ServerApi();
        }
        return ServerApi.instance;
    }
}
</script>

<style></style>