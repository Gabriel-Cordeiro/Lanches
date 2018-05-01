module.exports = (app) => {
    app.get('/', (req, res) => {
        app.controllers.home.index(app, req, res)
    })
}