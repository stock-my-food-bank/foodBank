import BasicButton from './BasicButton'

function SurveyPage() {
  return (

    <>
        {/* //NavBar Heading */}
        <nav className="navbar bg-body-tertiary bg-info">
            <div classNme="container-fluid">
                <span className="navbar-brand mb-0 h1">StockMyFoodBank</span>
            </div>
        </nav>

        {/* Survey Button */}
        <div className="d-flex flex-row-reverse">
            <BasicButton text="Results"/>
        </div>

        {/* Survey Heading  */}
        <h1>
            StockMyFoodBank
        </h1>

        {/* Survey Container  */}
        <div className="container-md bg-info">
          
            <p>View 1 and View 2 Container </p>
        </div>

        
        {/* Survey Footer  */}
        <nav className="navbar bg-body-tertiary">
            <div classNme="container-fluid">
                <span className="navbar-brand mb-0 h1 ">StockMyFoodBank</span>
            </div>
        </nav>
    </>
    
  
    // <div className="Container-fluid"> 
    //     <nav className="navbar navbar-light bg-info">
    //         <div className="container-fluid">
    //             <span className="navbar-brand mb-0 h1">StockMyFoodBank</span>
    //         </div>
    //     </nav>
    //     <div>
    //         <BasicButton text="Results"/>
    //     </div>
    //     <h1>
    //         StockMyFoodBank
    //     </h1>
    //     <div className="Container-fluid bg-info"> 
    //         <div className="col">
    //             <ul className="list-group">
    //                 <li className="list-group-item d-flex justify-content-between align-items-start">
    //                 <div className="ms-2 me-auto">
    //                     <div className="fw-bold">Item 1</div>
    //                     Description
    //                     </div>
                        
    //                 </li>
    //                 <li className="list-group-item d-flex justify-content-between align-items-start">
    //                     <div className="ms-2 me-auto">
    //                     <div className="fw-bold">Item 2</div>
    //                     Description
    //                     </div>
                        
    //                 </li>
    //                 <li className="list-group-item d-flex justify-content-between align-items-start">
    //                     <div className="ms-2 me-auto">
    //                     <div className="fw-bold">Item 3</div>
    //                         Descriptionn
    //                     </div>
                        
    //                 </li>
    //             </ul>
    //         </div>
    //         <div className="col">
    //             Columns2
    //             <ul>
    //                 <li>
    //                     <button type="button" class="btn btn-primary" data-bs-toggle="button" autocomplete="off">Toggle button</button>
    //                     <button type="button" class="btn btn-primary active" data-bs-toggle="button" autocomplete="off" aria-pressed="true">Active toggle button</button>
    //                     <button type="button" class="btn btn-primary" disabled data-bs-toggle="button" autocomplete="off">Disabled toggle button</button>
    //                 </li>
    //             </ul>
    //         </div>
    //     </div>
    
    // </div>
    
    
  );
}

export default SurveyPage;