//Nyambura --Results page
import { Outlet } from "react-router-dom";

//logo imported 
import Logo from "../Logo";
//basic button stylin imported 
import BasicButton from "../BasicButton";
//RPComments imported 
import RPComments from "./RPComments";



function ResultsPage() {
    console.log("test connection")
    return (
        <div className="Container-fluid"> 
            {/* Header with logo */}
            {/* Accessibility -Semantic html text header */}
            <header>
                <Logo/>
            </header>

            {/* Back Button for Results Page */}
            {/* Accessibility -role added for navigation, with aria label*/}
            <section className="d-flex mt-2 ms-5" role="navigation">
                <BasicButton text="Back" aria-label="Go Back to Previous Page"/>
            </section>

            {/* Accessibility --Main Content Section, semantic html for headers */}
            <main>
                {/* StockMyFoodBank Header  */}
                <h1 id="main-title">
                    StockMyFoodBank
                </h1>
                
                <section className="Container-fluid Stock Color ms-5 me-5">
                    <h2 id="results-heading">
                        Results
                    </h2>

                    {/*Table that will display individual item results in table format */}
                    {/* Accessibility --semantic html for section, caption for table and Aria roles added to table as well as keyboard navigation using tab */}
                    <section className="Container-md bg-light me-5 ms-5">
                        <table class="table table-bordered" aria-describedby="results-heading" tabIndex="0">
                            <caption tabIndex="0">Results of the StockMyFoodBank survey of items being considered by the foodbank</caption>
                            <thead>
                                
                                <th tabIndex="0">
                                    Item1

                                </th>
                                
                                
                            </thead>
                            <tbody>
                                <tr>
                                    <th scope="row" tabIndex="0">Yes</th>
                                    <td tabIndex="0">#</td>
                                
                                </tr>
                                <tr>
                                    <th scope="row" tabIndex="0">No</th>
                                    <td tabIndex="0">#</td>
                                
                                </tr>
                                
                            </tbody>
                        </table>

                    </section> 
                    
                    <div>
                        <RPComments />
                    </div>

                    
                </section> 
            
            </main>

            {/* Footer for view 2 Results page */}
            <footer>
                <Logo />
            </footer>

        </div>        
    );
}

export default ResultsPage;

