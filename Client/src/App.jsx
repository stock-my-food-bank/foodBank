import { useEffect, useState } from 'react';
import {BrowserRouter, Routes, Route} from 'react-router-dom';
import './App.css'
import SurveyPage from './Components/SPComponents/SurveyPage';
import ResultsPage from './Components/RPComponents/ResultsPage';



function App() {
  const [count, setCount] = useState(0)

  /*working call to server and sqlite info -Sarah
  always add a , [] as second param in useeffect so it's only called once
  */
  useEffect(()=> {
    fetch('https://localhost:7183/api/Users').then(res=>{
      res.json().then(json=> {console.log(json)
        setCount(json)
      })
    })
  }, [])

  return (

    <BrowserRouter>
      <Routes>
        {/* Root path is Survey Page */}
        <Route path="/" element={<SurveyPage/>}/>
        {/* Lowercase path name shown to user in url, path to ResultsPage */}
        <Route path="/results" element={<ResultsPage/>}/>
      </Routes>
    </BrowserRouter>
      
  );
}

export default App
