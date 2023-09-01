<template>
  <h1>
    <div>
      {{ title }}
    </div>
  </h1>
  <br>
  <Modal />
</template>

<script>
import Modal from './components/Modal.vue'

export default {
  name: 'App',
  components: { Modal },
  data() {
    return {
      title: 'VERY LOOOOOONG TEXTXXXXXXTTTT'
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
h1 {
  border-bottom: 5px solid #eb4b4b;
  display: inline-block;
  padding-bottom: 10px;
}
</style>
