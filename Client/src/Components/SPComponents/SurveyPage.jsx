//Nyambura --Imported Basic Button Styling  
import BasicButton from '../BasicButton'
//Nyambura --Imported Food Item list 
import FoodItems from './FoodItems';
//Nyambura --Imported comments component 
import Comments from './Comments';
//Nyambura --Imported Logo component 
import Logo from '../Logo';
//Imported Pagination 
import Pagination from '../Pagination';

function SurveyPage() {
  return (
    
  
    <div className="Container-fluid"> 
        {/* Header  */}
       <div>
            <Logo/>
       </div>

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
        {/* Pagination  */}
        <div>
            <Pagination />

        </div>

        {/* Comments section added for view 1 survey page  */}
        <div>
            <Comments />
        </div>

        {/* Submit Button for Survey Page, styled to be in the middle of page */}
        <div className="d-flex justify-content-center ">
            <BasicButton text="Submit"/>
        </div>

        {/* Footer for view 1 survey page */}
        <div>
            <Logo />
       </div>
           
    
    </div>
    
    
  );
}

export default SurveyPage;