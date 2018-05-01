module.exports = (app) => {
    app.get('/prontos', (req, res) => {
        app.controllers.lanches.lanchesProntos(app, req, res)
    })

    app.get('/customizados', (req, res) => {
        app.controllers.lanches.lanchesCustomizados(app, req, res)
    })

    app.post('/calcularCustomizado', (req, res) => {
        app.controllers.lanches.CalcularlancheCustomizado(app, req, res)
    })
}

