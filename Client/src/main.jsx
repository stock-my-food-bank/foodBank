import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.jsx'
// Import our custom CSS
import 'bootstrap/dist/css/bootstrap.min.css'

//Nyambura --Imports ReactDOM library through {}, as well as renders root inside of create root function. 3 steps in 1. 
createRoot(document.getElementById('root')).render(
  <StrictMode>
    <App />
  </StrictMode>
)
