//Nyambura --Popup for error and survey submission
//Murphree -- saved for future iterations - alerts are being used for this prototype
function Popup (props) {
    return (
        <>
            <div class="modal" tabIndex="-1">
                <div className="modal-dialog">
                    <div className="modal-content">
                    <div className="modal-header bg-secondary">
                        {/* Header of popup can be changed here */}
                        <h5 className="modal-title">{props.header}</h5>
                        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div className="modal-body">
                        {/* Body of Popup can be changed here */}
                        <p>{props.text}</p>
                    </div>
                    <div className="modal-footer">
                        <button type="button" className="custom-btn" data-bs-dismiss="modal">Ok</button>
                        
                    </div>
                    </div>
                </div>
            </div> 
        </>

    );
}
export default Popup; 