 
/* Nyambura --Basic Button functional component*/ 

function BasicButton(props) {

    return (
       
        <div>
            <button className="custom-btn m-3 " onClick={props.onClickHandler}>
        
                {props.text}
            </button>
        </div>
        
    );
}
export default BasicButton;
