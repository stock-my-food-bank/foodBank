//Nyambura --Popup for error and survey submission

function Popup (props) {
    return (
        <>
            <div class="modal" tabindex="-1">
                <div class="modal-dialog">
                    <div class="modal-content">
                    <div class="modal-header bg-secondary">
                        {/* Header of popup can be changed here */}
                        <h5 class="modal-title">{props.header}</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        {/* Body of Popup can be changed here */}
                        <p>{props.text}</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="custom-btn" data-bs-dismiss="modal">Ok</button>
                        
                    </div>
                    </div>
                </div>
            </div> 
        </>

    );
}
export default Popup; 