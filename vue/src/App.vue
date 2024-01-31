<template>
 <v-app>
  <SideBar/>
  
<v-main>
<TrickView></TrickView>
</v-main>

 </v-app>
</template>

<script setup>
  import SideBar from "../src/components/Sidebar.vue"
import TrickView from "../src/views/TrickView.vue"
</script>

