<template>
  <h1>
    <div>
      {{ title }}
    </div>
  </h1>
  <br>
  <div v-if="showModal">
    <Modal :counter="counter" :theme="getTheme" @close="modalToggle">
      <template v-slot:links>
        <a href="#">Sign up</a>
        <a href="#">More info</a>
      </template>
      <h1>HElloo header</h1>
      <p>some additional text</p>
    </Modal>
  </div>
  <div v-if="showModalSecond">
    <Modal :counter="counter" :theme="getTheme" @close="modalToggleSecond">
      <template v-slot:links>
        <a href="#">Only one link!</a>
      </template>
      <h1>Very diffent modal here!</h1>
    </Modal>
  </div>
  <button @click="increaseCounter" class="button-62">click me!</button>
  <button @click="saleToggle" class="button-62">Sale?</button>
  <button @click="modalToggle" class="button-62">Show modal</button>
  <button @click="modalToggleSecond" class="button-62">Show second modal</button>
</template>

<script>
import Modal from './components/Modal.vue'

export default {
  name: 'App',
  components: { Modal },
  data() {
    return {
      title: 'VERY LOOOOOONG TEXTXXXXXXTTTT',
      modalHeader: 'TEST HeAdEr',
      modalText: 'And some text here',
      counter: 0,
      showModal: false,
      showModalSecond: false,
      isSale: true,
    }
  },
  methods: {
    increaseCounter() {
      this.counter++;
    },
    modalToggle(){
      this.showModal = !this.showModal
    },
    modalToggleSecond(){
      this.showModalSecond = !this.showModalSecond
    },
    saleToggle(){
      this.isSale = !this.isSale
    }
  },
  computed: {
    getTheme() {
      if(this.isSale){
        return 'sale'
      }
      else{
        return 'noSale'
      }
    }
  }
}

</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
button {
    color: #333;
    padding: 8px;
    border: 1px solid #eee;
    border-radius: 4px;
    margin: 10px;
    text-decoration: none;
    stroke: 1px #333;
  }
h1 {
  border-bottom: 5px solid #eb4b4b;
  display: inline-block;
  padding-bottom: 10px;
}

/* CSS */
.button-62 {
  background: linear-gradient(to bottom right, #EF4765, #FF9A5A);
  border: 0;
  border-radius: 12px;
  color: #FFFFFF;
  cursor: pointer;
  display: inline-block;
  font-family: -apple-system,system-ui,"Segoe UI",Roboto,Helvetica,Arial,sans-serif;
  font-size: 16px;
  font-weight: 500;
  line-height: 2.5;
  outline: transparent;
  padding: 0 1rem;
  text-align: center;
  text-decoration: none;
  transition: box-shadow .2s ease-in-out;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
  white-space: nowrap;
}

.button-62:not([disabled]):focus {
  box-shadow: 0 0 .25rem rgba(0, 0, 0, 0.5), -.125rem -.125rem 1rem rgba(239, 71, 101, 0.5), .125rem .125rem 1rem rgba(255, 154, 90, 0.5);
}

.button-62:not([disabled]):hover {
  box-shadow: 0 0 .25rem rgba(0, 0, 0, 0.5), -.125rem -.125rem 1rem rgba(239, 71, 101, 0.5), .125rem .125rem 1rem rgba(255, 154, 90, 0.5);
}
</style>
