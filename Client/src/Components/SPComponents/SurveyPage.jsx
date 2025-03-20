// Needed for routes as we are importing from the library
import { Link } from 'react-router-dom';

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
//Imported PopUp 
import Popup from './Popup';

function SurveyPage() {

    //useEffect

    //popup controls

    // submit handler (votes & comment)
  return (
    
  
    <div className="Container-fluid "> 
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
        <div className="Container-md Stock-Color">
            <FoodItems
            _submitHandler={submitHandler}
            />
        </div>
        {/* Pagination - SM removing for now for prototype */}
        <div>
            <Pagination />

        </div>

        {/* Comments section added for view 1 survey page  */}
        <div>
            <Comments />
        </div>

        {/* Submit Button for Survey Page, styled to be in the middle of page */}
        <div className="d-flex justify-content-center ">
          <Link to="/results"> <BasicButton text="Submit"/></Link>
        </div>
        {/* Popup modal can alter header and text using props to show error and submitted popup when submit button is clicked  */}
        <div>
            <Popup/>
        </div>

        {/* Footer for view 1 survey page */}
        <div>
            <Logo />
       </div>              
    </div>
    
    
  );
}

export default SurveyPage;