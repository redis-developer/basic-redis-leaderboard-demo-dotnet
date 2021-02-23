<template>
  <v-app id="app" class="mt-0">
    <div style="position: absolute; top: -50px; right: 0px; width: 300px;">
      <img src="https://redislabs.com/wp-content/uploads/2020/12/RedisLabs_Illustration_HomepageHero_v4.svg">
    </div>

    <div style="height: 50px" />

    <h1 class="text-center" style="color: #444444;">Redis Leadboard Demo</h1>

    <div style="height: 50px" />

    <example />
  </v-app>
</template>

<script>
import Example from './components/Example.vue'

export default {
  name: 'App',
  components: {
    Example,
  }
}
</script>

<style>
#app {
  /*font-family: Avenir, Helvetica, Arial, sans-serif;*/
  font-family: 'Noto Sans JP', sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin-top: 60px;

  background: #f4f4f4;
}
pre {
  background: #f6f8fa;
  padding: 3px 5px;
  display: inline;
}
</style>
