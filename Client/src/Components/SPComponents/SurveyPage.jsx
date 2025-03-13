//Nyambura --Imported Basic Button Styling  
import BasicButton from '../BasicButton'
//Nyambura --Imported Food Item list 
import FoodItems from './FoodItems';

function SurveyPage() {
  return (
    
  
    <div className="Container-fluid"> 
        {/* Nav Bar  */}
        <nav className="navbar navbar-light bg-info">
            <div className="container-fluid">
                <span className="navbar-brand mb-0 h1">StockMyFoodBank</span>
            </div>
        </nav>
        {/* Results Button for Survey Page, styled to start from opposite side */}
        <div className="d-flex flex-row-reverse">
            <BasicButton text="Results"/>
        </div>
        {/* StockMyFoodBank Header  */}
        <h1>
            StockMyFoodBank
        </h1>
        {/* Container that hold view 1 survey page food items */}
        <div className="Container-md bg-info">
            <FoodItems/>
        </div>
        {/* Footer for view 1 survey page */}
        <nav className="navbar navbar-light bg-info">
            <div className="container-fluid">
                <span className="navbar-brand mb-0 h1">StockMyFoodBank</span>
            </div>
        </nav>
           
    
    </div>
    
    
  );
}

export default SurveyPage;