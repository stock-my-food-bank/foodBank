import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
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
      <div>
        <a href="https://vite.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
        <p>
          Edit <code>src/App.jsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
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
