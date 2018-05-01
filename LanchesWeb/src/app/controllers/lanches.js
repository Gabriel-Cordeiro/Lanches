const lanchesProntos = (app, req, res) => {

    let LanchesModel = new app.models.LanchesDAO()
    LanchesModel.pegarTodosLanches((err, cb) => {
        let arrayLanches = JSON.parse(cb.body)
        res.render('lanches/lanchesProntos', { arrayLanches })
    })
}


const lanchesCustomizados = (app, req, res) => {
    let ingredientesModel = new app.models.IngredientesDAO()
    ingredientesModel.pegarTodosIngredientes((err, cb) => {
        let arrayIngredientes = JSON.parse(cb.body)
        res.render('lanches/LanchesCustomizados', { arrayIngredientes })
    })
}

const CalcularlancheCustomizado = (app, req, res) => {
    const result = []

    Object.entries(req.body).forEach(([key, value]) => {
        const val = parseInt(value)
        if (val > 0) {
            Array.prototype.forEach.call(Array(val).fill(), () => {
                result.push({ NomeIngrediente: key })
            })
        }
    })

    let jsonResult = JSON.stringify(result)
    let lanchesModel = new app.models.LanchesDAO()

    lanchesModel.pegarValoresLanchesCustomizado(jsonResult, function (dadosLancheCustomizado){
        let arrayLanche = JSON.parse(dadosLancheCustomizado)
        res.render('lanches/LancheCustomizadoVenda', { arrayLanche })

    })
}

module.exports = {
    lanchesProntos,
    lanchesCustomizados,
    CalcularlancheCustomizado,
}