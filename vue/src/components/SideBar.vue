

<template>
    <v-navigation-drawer expand-on-hover rail>
        <v-list>
            <v-list-item prepend-avatar="https://randomuser.me/api/portraits/women/85.jpg" title="Daniel Kennedy"
                subtitle="danpatvern@gmailcom"></v-list-item>
        </v-list>

        <v-divider></v-divider>
        <v-list density="compact" nav>

            <v-list-item prepend-icon="mdi-image" title="Home" value="home">
               
            </v-list-item>
            <v-list-item prepend-icon="mdi-account-multiple" title="My Tricks" value="tricks">
            </v-list-item>

        </v-list>

    </v-navigation-drawer>
</template>

<script>
import SvgIcon from '@jamescoyle/vue-icon';
import { mdiAccount } from '@mdi/js';
export default {
    name: "my-component",

    components: {
        SvgIcon
    },
    data() {
        return {
            path: mdiAccount,
        }
    }
}
</script>