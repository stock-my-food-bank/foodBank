import { useEffect, useState } from 'react'
import './App.css'
import SurveyPage from './Components/SurveyPage';
import BasicButton from './Components/BasicButton';



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
    <>
      
     
      {/*Nyambura --SurveryPage */}
      <div>
        <SurveyPage />
      </div>
      
      {/*Nyambura --Results button*/}
      <div>
        <BasicButton text="Results"/>
      </div>
      
     {/*Nyambura --Submit button*/}
      <div>
        <BasicButton text="Submit"/>
      </div>

    </>
  )
}

export default App
