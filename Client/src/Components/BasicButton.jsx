 
/* Nyambura --Basic Button functional component*/ 

function BasicButton(props) {
    //handleBtn function defined 
    const handleBasicButton = () => {

        console.log(props.text + 'Button Clicked!')
       
    };

    return (
       
        <div>
            <button className="custom-btn m-3 " onClick={handleBasicButton}>
        
                {props.text}
            </button>
        </div>
        
    );
}
export default BasicButton;
