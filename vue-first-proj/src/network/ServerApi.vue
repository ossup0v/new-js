<template>
    <p>Test</p>
    <input type="text" v-model="objectId">
    <button @click="sendStringg">Click me!</button>
</template>

<script>
import axios from 'axios';

export default {
    data() {
        return {
            objectId: 'test'
        }
    },
    methods: {
        sendStringg() {
            // Usage:
            const serverApi = ServerApi.getInstance();

            // Send a string to a specific path
            const path = 'post-test-object'; // Change this to your desired path
            const testObject = {
                Id: this.objectId,
                Name: 'Misha',
                Age: 21
            }
            serverApi.sendTestObject(path, testObject)
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

    sendTestObject(path, myObject) {
        const url = `${ServerApi.instance.baseUrl}/${path}`;

        console.log(myObject)

        return axios.post(url, myObject)
            .then(response => {
                console.log(response.data); // Handle the response from the server
            })
            .catch(error => {
                console.error(error);
            });

        // return fetch(url, {
        //     method: 'POST',
        //     headers: {
        //         'accept': 'text/plain',
        //         'Content-Type': 'application/json',
        //     },
        //     body: myString,
        // })
        //     .then(response => {
        //         if (!response.ok) {
        //             throw new Error('Network response was not ok' + response);
        //         }
        //         return response.text(); // or response.json() if the server responds with JSON
        //     })
        //     .catch(error => {
        //         throw error;
        //     });
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