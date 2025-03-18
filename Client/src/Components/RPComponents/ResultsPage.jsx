//Nyambura --Results page

//logo imported 
import Logo from "../Logo";
//basic button stylin imported 
import BasicButton from "../BasicButton";



function ResultsPage() {
    return (
        <>
            <div className="Container-fluid"> 
                {/* Header  */}
                <div>
                    <Logo/>
                </div>

                {/* Back Button for Results Page */}
                <div className="d-flex mt-2 ms-5">
                    <BasicButton text="Back"/>
                </div>
               

                {/* StockMyFoodBank Header  */}
                <h1>
                    StockMyFoodBank
                </h1>

               
                <div className="Container-fluid bg-info ms-5 me-5">
                    <h2>
                        Results
                    </h2>

                    {/*Table that will display individual item results in table format */}
                    <div className="Container-md bg-light me-5 ms-5">
                        <table class="table table-bordered">
                            <thead>
                               
                                <th>
                                    Item1

                                </th>
                                
                                
                            </thead>
                            <tbody>
                                <tr>
                                    <th scope="row">Yes</th>
                                    <td>#</td>
                                
                                </tr>
                                <tr>
                                    <th scope="row">No</th>
                                    <td>#</td>
                                
                                </tr>
                                
                            </tbody>
                        </table>

                    </div> 

                    
                </div> 
                

                {/* Footer for view 2 Results page */}
                <div>
                    <Logo />
                </div>
                
            
            </div>
        </>

    );
}

export default ResultsPage;