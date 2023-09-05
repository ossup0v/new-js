<template>
    <form>
        <label>Email: </label>
        <input type="email" required v-model="email">
    
        <label>Password: </label>
        <input type="password" required v-model="password">

        <label>Role:</label>
        <select v-model="role">
            <option value="developer">Web developer</option>
            <option value="designer">Web designer</option>
        </select>
        
        <div class="terms">
            <input type="checkbox" v-model="termsAcceptance" required>
            <label>Accept terms</label>
        </div>

        <div>
            <input type="checkbox" value="Sushi" v-model="names">
            <label>Sushi</label>
            <br>
            <input type="checkbox" value="mamagaba" v-model="names">
            <label>mamagaba</label>
            <br>
            <input type="checkbox" value="pupagamimo" v-model="names">
            <label>pupagamimo</label>
        </div>
    </form>
    <button @click="submitEmail">Submit</button>
    <br>
    <p>Passwrod {{ password }}</p>
    <p>Terms {{ termsAcceptance }}</p>
    <p>Names {{ names }}</p>
</template>

<script>
export default {
    data() {
        return {
            email: '',
            password: '',
            role: '',
            termsAcceptance : false,
            names: []
        }
    },
    methods : {
        submitEmail() {
            console.log(this.email)
            this.$emit('emailSubmited', this.email)
        }
    }
}

</script>


<style>
    form {
        max-width: 420px;
        margin: 30px auto;
        background: white;
        text-align: left;
        padding: 40px;
        border-radius: 10px;
    }
    label {
        color: #aaa;
        display: inline-block;
        margin: 25px 0 15px;
        font-size: 0.6em;
        text-transform: uppercase;
        letter-spacing: 1px;
        font-weight: bold;
    }
    input, select {
        display: block;
        padding: 10px 6px;
        width: 100%;
        box-sizing: border-box;
        border: none;
        border-bottom: 1px solid #ddd;
        color: #555;
    }
    input[type="checkbox"] {
        display: inline-block;
        width: 16px;
        margin: 0 10px 0 0;
        position: relative;
        top: 2px;
    }
</style>