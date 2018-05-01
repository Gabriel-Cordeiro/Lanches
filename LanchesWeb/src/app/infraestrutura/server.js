import express from 'express'
import consign from 'consign'
import bodyParser from 'body-parser'
import expressValidator from 'express-validator'


const app = express()
app.set('view engine', 'ejs')
app.set('views', './src/app/views')

app.use(express.static('./src/app/public'))
app.use(bodyParser.urlencoded({ extended: true }))
app.use(expressValidator())

consign()
    .include('src/app/routes')
    .then('src/app/models')
    .then('src/app/controllers')
    .into(app)

export default app