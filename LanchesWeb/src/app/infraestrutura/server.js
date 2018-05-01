const express = require('express')
const consign = require('consign')
const bodyParser = require('body-parser')
const expressValidator = require('express-validator')


const app = express()
app.set('view engine', 'ejs')
app.set('views', './views')

app.use(express.static('./public'))
app.use(bodyParser.urlencoded({ extended: true }))
app.use(expressValidator())

consign()
    .include('./routes')
    .then('./models')
    .then('./controllers')
    .into(app)

module.exports = app