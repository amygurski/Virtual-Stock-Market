<template>
<div class="table-responsive">
        <table class=" table table-hover" v-if="data">
            <thead>
                <tr>
                    <th scope="col">Creator</th>
                    <th scope="col">Game Name</th>
                    <th scope="col">Date Created</th>
                    <th scope="col">Game Ends</th>
                </tr>
            </thead>
            <tbody>
                <tr v-bind:key="game" v-for="game in data">
                    <td>{{ game.creatorUsername }}</td>
                    <td>{{ game.gameName }}</td>
                    <td>{{ game.dateCreated }}</td>
                    <td>{{ game.endDate }}</td>
                    <td>
                        <button type="button" class="btn btn-teal btn-rounded btn-sm m-0">
                            Join Game
                        </button>
                    </td>
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
        data: []
    };
},

mounted() {
    this.getData();

},

methods: {
    getData() {
        // vue-resource example
        fetch(`${process.env.VUE_APP_REMOTE_API}/games/currentgames`).then(response => {
            return response.json();
        }).then(jsonData => {
            this.data = jsonData;
        }).catch(e => {
            console.log('Error', e);
        });
    }
},

};

</script>

<style scoped>


</style>