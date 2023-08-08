<template>
 
    <div id="app">
        <the-header></the-header>
        
    <router-view></router-view>
    </div>
</template>
<script>
import TheHeader from './components/nav/TheHeader.vue';

export default{
    name:'App',
    components:{
        TheHeader,
    }
}

</script>
<style scoped>

@import url('https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap');

* {
  box-sizing: border-box;
}

html {
  font-family: 'Roboto', sans-serif;
}

body {
  margin: 0;
}
</style>

