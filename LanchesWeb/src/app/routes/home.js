module.exports = (app) => {
    app.get('/', (req, res) => {
        app.src.app.controllers.home.index(app, req, res)
    })
}