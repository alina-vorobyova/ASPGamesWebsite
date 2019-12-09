const apiUrl = 'https://api.rawg.io/api';
//let selectedOptionInDatalist = 

async function SearchGameByName(gameName) {
    let response = await fetch(`${apiUrl}/games?search=${gameName}&ordering=-rating&page_size=10`);
    if (response.status != 200) throw response;
    return response.json();
}

let app = new Vue({
        el:  "#app",

        data: {
            gameName: '',
            gameList: [],
           
        },

        methods: {
            //onGameProductFormSubmit: async function () {
            //    let response = await SearchGameByName(this.gameName);
            //    this.gameList = response.results;
            //    console.log(response.results);

            //},
            onInputChanged:async function () {
                let response = await SearchGameByName(this.gameName);
                this.gameList = response.results;
                console.log(response.results);
            }
        }
    });