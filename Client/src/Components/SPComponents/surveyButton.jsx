function SurveyButton (props) {
    const [id]=props
    return (
        <div>
            <div className="btn-group" role="group" aria-label="Basic outlined example">
                <button type="button" className="btn btn-outline-dark">Yes</button>
                <button type="button" className="btn btn-outline-dark">No</button>
                <button type="button" className="btn btn-outline-dark">Skip</button>
            </div>
        </div>
    );
}



                    

                    // {/* Column 2 -Food Item selection, Card Bootstrap */}
                    // <div className="card col-6 d-flex flex-column">
                    //     <div className="card-header">
                    //         Would you select this item during a visit? 
                    //     </div>
                    //     <div className="card-body flex-fill">

                    //         {/* Ordered list that holds button groups for each food item being considered, button group bootstrap  */}
                    //         <ol className="list-group list-group-numbered">
                    //             {/* Individual button group for each food item selection  */}
                    //             <li className="list-group-item p-3">
                                    
                    //                 <div className="btn-group" role="group" aria-label="Basic outlined example">
                    //                     <button type="button" className="btn btn-outline-dark">Yes</button>
                    //                     <button type="button" className="btn btn-outline-dark">No</button>
                    //                     <button type="button" className="btn btn-outline-dark">Skip</button>
                    //                 </div>
                    //             </li>
                                
                                
                                    
                    //         </ol>
                                
                    //     </div>
                    // </div>