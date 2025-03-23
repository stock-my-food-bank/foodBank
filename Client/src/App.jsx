import { useEffect, useState } from 'react';
import {BrowserRouter, Routes, Route} from 'react-router-dom';
import './App.css'
import SurveyPage from './Components/SPComponents/SurveyPage';
import ResultsPage from './Components/RPComponents/ResultsPage';



function App() {

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
