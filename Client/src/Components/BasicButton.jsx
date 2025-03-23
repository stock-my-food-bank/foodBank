 
/* Nyambura --Basic Button functional component*/ 
export const BasicButton = (props) => {

    return (
        <button className="custom-btn m-3 " onClick={props.onClickHandler}>
            {props.text}
        </button>
    );
}
