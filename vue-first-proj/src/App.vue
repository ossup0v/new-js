<template>
  <div v-if="!inputToggleFlag">
    <button @click="showToggle" v-if="!showToggleFlag">Show</button>
    <button @click="showToggle" v-else>Close</button>
  </div>

  <div v-if="!showToggleFlag">
    <button @click="inputToggle" v-if="!inputToggleFlag">Input</button>
    <button @click="inputToggle" v-else>Close</button>
  </div>
  <Show v-if="showToggleFlag" />
  <Input v-if="inputToggleFlag" />
</template>

<script>
import Show from './components/Show.vue'
import Input from './components/Input.vue'

export default {
  name: 'App',
  components: {
    Show,
    Input
  },
  data() {
    return {
      showToggleFlag: false,
      inputToggleFlag: false,
    }
  },
  methods: {
    showToggle() {
      this.showToggleFlag = !this.showToggleFlag
    },
    inputToggle() {
      this.inputToggleFlag = !this.inputToggleFlag
    },
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
</style>
