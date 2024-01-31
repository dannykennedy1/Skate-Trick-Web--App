<template>
    <v-sheet
    border="md"
    class="pa-6 text-white mx-auto"
    color="#141518"
    max-width="400">
        <h2>Bagged</h2>

        <TrickCard v-for="trick in this.$store.state.tricks" :key="trick.id" :trick="trick"></TrickCard>
        
    </v-sheet>
  </template>

<script>
import TrickCard from "./TrickCard.vue";
import trickService from "../services/TrickService";

export default {
  data: () => ({
    return: {
       
        trick: {}

    }
  }),
methods: {
    loadTricks() {
      trickService
        .listTricks()
        .then((response) => {
          console.log(response);
          console.log("Reached listTricks in the trickContainer component");
          this.$store.state.tricks = response.data;
        })
        .catch((error) => {
          if (error.response) {
            console.log("Error loading trick: ", error.response.status);
          } else if (error.request) {
            console.log("Error loading trick: unable to communicate to server");
          } else {
            console.log("Error loading trick: make request");
          }
        });
    },
   
},

  created() {
    console.log("reached created in the trick component")
    
    this.loadTricks()
  },
  components: {TrickCard}
}
</script>