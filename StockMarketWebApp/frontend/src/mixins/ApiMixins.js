  export default {
    methods: {
        getHistoricalStockDataByStockAndStartDate(apiModel, token) {
            fetch(`${process.env.VUE_APP_REMOTE_API}/transactions/getbygameanduser`, {
              method: "POST",
              headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
                Authorization: "Bearer " + token
              },
              body: JSON.stringify(apiModel)
            })
              .then(response => {
                return response.json();
              })
              .then(json => {
                return json;
              })
              .catch(e => {
                console.log("Error", e);
              });
          }
    }

}