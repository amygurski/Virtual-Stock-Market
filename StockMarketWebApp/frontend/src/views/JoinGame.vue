<template>
<div class="table-responsive">
        <table class="table-hover" v-if="data">
            <thead>
                <tr>
                    <th>Creator</th>
                    <th>Game Name</th>
                    <th>Date Created</th>
                    <th>Game Ends</th>
                </tr>
            </thead>
            <tbody>
                <tr v-bind:key="game" v-for="game in list">
                    <td>{{ game.creator }}></td>
                    <td>{{ game.gameName }}></td>
                    <td>{{ game.dateCreated }}></td>
                    <td>{{ game.dateEnd }}></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
export default {
    name: 'join-game',
data() {
    return {
        data: null
    };
},

mounted() {
    this.getData();

},

methods: {
    getData() {
        // vue-resource example
        this.$http.get('data.json', {responseType: 'json'}).then(response => {
            return response.json();
        }).then(jsonData => {
            this.data = JSON.parse(jsonData);
        }).catch(e => {
            console.log('Error', e);
        });
    }
}
};

</script>

<style scoped>


</style>