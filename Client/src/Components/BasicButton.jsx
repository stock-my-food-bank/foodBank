
/* Nyambura --Basic Button functional component*/ 

function BasicButton(props) {
    //handleBtn function defined 
    const handleBasicButton = () => {

        console.log(props.text + 'Button Clicked!')
       
    };

    return (
       
        <div>
            <button className="btn btn-info" onClick={handleBasicButton}>
        
                {props.text}
            </button>
        </div>
        
    );
}
export default BasicButton;
