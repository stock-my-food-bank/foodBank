function FoodItems () {
         
    return (
        <>
            <div class="container-fluid ">
    
                <div className="row align-items-start p-5 pb-0">

                    {/* Nyambura Column 1 --Food items, Card Bootstrap */}
                    <div className="card col-6 d-flex ">
                        <div className="card-header">
                                Items being considered by the foodbank:
                        </div>
                        
                        <div className="card-body flex-fill">
                            {/* Nyambura -- Ordered list that holds every food item that will be considered, List Group Bootstrap  */}
                            <ol className="list-group list-group-numbered">

                                {/* Individual Food List Item example  */}
                                <li className="list-group-item d-flex justify-content-between align-items-start">
                                    <div className="ms-2 me-auto">
                                        <div className="fw-bold"> 
                                            Item 1
                                        </div>
                                        <p>
                                            Description
                                        </p>
                                    </div>
                                </li>
                                    
                            </ol>
                        </div>
                    </div>

                    {/* Column 2 -Food Item selection, Card Bootstrap */}
                    <div className="card col-6 d-flex flex-column">
                        <div className="card-header">
                            Would you select this item during a visit? 
                        </div>
                        <div className="card-body flex-fill">

                            {/* Ordered list that holds button groups for each food item being considered, button group bootstrap  */}
                            <ol className="list-group list-group-numbered">
                                {/* Individual button group for each food item selection  */}
                                <li className="list-group-item p-3">
                                    
                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                        <button type="button" className="btn btn-outline-dark">Yes</button>
                                        <button type="button" className="btn btn-outline-dark">No</button>
                                        <button type="button" className="btn btn-outline-dark">Skip</button>
                                    </div>
                                </li>
                                
                                
                                    
                            </ol>
                                
                        </div>
                    </div>
                </div>
            </div> 
        </>
    );
    
}

export default FoodItems;