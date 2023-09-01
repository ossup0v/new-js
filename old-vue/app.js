const app = Vue.createApp({
    //template: '<h2>Im template</h2>'
    data() {
        return {
            show: true,
            url: 'https://google.com',
            testField: 'YEASSSSS TEST FIELD',
            counts: 1,
            show1: true,
            show2: false,
            show3: false,
            show4: false,
            x: null,
            y: null,
            XYtext: null,
            exspenses: [
                { category: 'eat', amountUSD: 25, imagePath: 'assets/eat.png', isFavorite:true },
                { category: 'rent', amountUSD: 850, imagePath: 'assets/rent.png', isFavorite:false },
                { category: 'taxi', amountUSD: 200, imagePath: 'assets/taxi.png', isFavorite:true },
                { category: 'invest', amountUSD: -50, imagePath: 'assets/invest.png', isFavorite:true },
                { category: 'other', amountUSD: 9999, imagePath: 'assets/other.png', isFavorite:false },
            ],
            totalExspenses: 0
        }
    },
    methods: {
        changeTestFiled(newValue) {
            this.testField = newValue
        },
        changeShowState() {
            this.show = !this.show
        },
        increateCounts() {
            this.counts++;
        },
        handleMouseEvent(e, a){
            console.log(e, e.type)
            if(a) {
                console.log(a)
            }
        },
        handleMouseMoveEvent(e) {
            this.x = e.offsetX
            this.y = e.offsetY
            this.XYtext = this.x + ' : ' + this.y
        },
        toggleFavorite(exspense){
            exspense.isFavorite = !exspense.isFavorite 
        }
    },
    computed: {
        favoriteExspenses() {
            return this.exspenses.filter(x=>x.isFavorite)
        },
        notFavoriteExspenses() {
            return this.exspenses.filter((x) => !x.isFavorite);
        },
        getTotalExspenses() {
            totalExspenses = 0;
            for (let index = 0; index < this.exspenses.length; index++) {
                const element = this.exspenses[index];
                totalExspenses += element.amountUSD;
            }
            return totalExspenses;
        }
    }
})

app.mount('#app')