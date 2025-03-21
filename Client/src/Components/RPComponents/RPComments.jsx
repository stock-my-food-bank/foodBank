import React, { useEffect, useState } from "react";

//Nyambura --Functional component for results page comments for foodbank manager to review
function RPComments () {
    const [comments, setComments] = useState();
    const [commentCount, setCommentCount] = useState(5);
    
    useEffect(() => {
        const fn = async () => {
            const url = 'https://localhost:7183/api/Comments';
            try {
                const response = await fetch(url);
                if(!response.ok){
                    throw `Response Status: ${response.status}`;
                }
                const json = await response.json();
                setComments(json);
            } catch (error){
                alert(error.message);
            }
        };
        fn();
    }, []);

    if (!comments) {
        return 'loading...';
    }

    const showMoreOnClick = () => {
        setCommentCount(commentCount + 5);
    }

    console.log(comments);

    const visibleComments = comments.slice(0, commentCount <= comments.length ? commentCount : comments.length);

    return (
        <>
           <ul id='comment-table' className="list-group m-2">
                {visibleComments.map(c => <Comment comment={c.comment} date={c.dateTime} />)}
            </ul>
            <div>
                {commentCount < comments.length && <a href="#comment-table" onClick={showMoreOnClick}>Show More</a>}
            </div>
        </>
    );
}

const Comment = ({ comment, date }) => {
    return (
        <li className="list-group-item d-flex justify-content-between align-items-center">
            {comment}
            <span className="badge text-bg-light rounded-pill">Date: {date}</span>
        </li>
    )
}

export default RPComments; 