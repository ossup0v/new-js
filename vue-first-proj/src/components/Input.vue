<template>
  <form>
    <label>Размер траты </label>
    <input type="number" v-model="spendingAmount">
    <label>Валюта</label>
    <input type="text" v-model="spendingCurrency">
    <label>Категория</label>
    <input type="text" v-model="category">
    <label>Подкатегория</label>
    <input type="text" v-model="subCategory">
    <label>Тип траты</label>
    <input type="text" v-model="spendingType">
    <label>Комментарий</label>
    <input type="text" v-model="comment">
  </form>
  <button @click="sendToServer">Сохранить</button>
  <button @click="generate">Сгенерировать</button>
</template>

<script>
import ServerApi from '@/network/ServerApi';

export default {
  name: 'Show',
  data() {
    return {
      spendingAmount: 0,
      spendingCurrency: 'RUB',
      category: 'Taxes',
      subCategory: '',
      tags: ['hate this', 'need to don\'t forget'],
      spendingType: 'cash',
      comment: ''
    }
  },
  methods: {
    sendToServer() {
      var api = ServerApi.getInstance();
      api.sendSpending(this.spendingAmount
        , this.spendingCurrency
        , this.category
        , this.subCategory
        , this.tags
        , this.spendingType
        , this.comment)
    },
    generate() {
      ServerApi.getInstance().generateNewSpending();
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

input,
select {
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