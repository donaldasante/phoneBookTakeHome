import React, { useState, useEffect } from "react";



const SearchBar = ({ filter }) => {
    const [searchParam, setSearchParam] = useState("");

    const SearchClicked = (e) => {
        e.preventDefault();

        if (filter) {
            filter(searchParam);
        }
    }

    return (
        <div className={"row"}>
            <div className={"col-md-4"}>
                <div className={"form-inline"}>
                    <label className="sr-only" htmlFor="inlineFormInputName2">Name</label>
                    <input id="search-focus" type="search" id="form1" className={"form-control mb-2 mr-sm-2"} placeholder={"name or number"} value={searchParam} onChange={(e) => setSearchParam(e.target.value)} />

                    <button type="button" className={"btn btn-primary mb-2"} onClick={(e) => SearchClicked(e)}>
                        Search
                </button>
                </div>
            </div>
        </div>
    )
};

export default SearchBar;
