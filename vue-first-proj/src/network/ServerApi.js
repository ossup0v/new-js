import axios from 'axios'

class ServerApi {
    constructor() {
        this.baseUrl = 'http://localhost:8081'; // Change this to your server's base URL
    }

    sendSpending(spendingAmount
        , spendingCurrency
        , category
        , subCategory
        , tags
        , spendingType
        , comment) {

        this.sendPost('new-spending', {
            SpendAmount: {
                Currency: spendingCurrency,
                Amount: spendingAmount
            },
            Category: category,
            SubCategory: subCategory,
            Tags: tags,
            SpendingType: spendingType,
            Comment: comment
        })
    }

    getSpendings() {
        return this.sendGet('get-spendings')
    }

    generateNewSpending() {
        return this.sendPost('generate-new-spending')
    }

    sendPost(path, myObject) {
        const url = this.getUrl(path)

        console.log(myObject)

        return axios.post(url, myObject)
            .then(response => {
                console.log(response.data); // Handle the response from the server
                return response.data;
            })
            .catch(error => {
                console.error(error);
            });
    }

    sendGet(path) {
        const url = this.getUrl(path)

        return axios.get(url)
            .then(response => {
                console.log(response.data); // Handle the response from the server
                return response.data;
            })
            .catch(error => {
                console.error(error);
            });
    }

    getUrl(path) {
        return `${ServerApi.instance.baseUrl}/${path}`;
    }

    static getInstance() {
        if (!ServerApi.instance) {
            ServerApi.instance = new ServerApi();
        }
        return ServerApi.instance;
    }
}

export default ServerApi;