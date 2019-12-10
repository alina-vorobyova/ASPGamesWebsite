const apiUrl = 'https://api.rawg.io/api';

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
            onInputChanged:async function () {
                let response = await SearchGameByName(this.gameName);
                this.gameList = response.results;
                let searchedGame = $("input[type=search]").val().split(":");
                let gameId = searchedGame[0];
                $("#GameHiddenInput").val(gameId);
                //console.log(searchedGame[0]);
                //console.log(response.results);
            }
        }
    });