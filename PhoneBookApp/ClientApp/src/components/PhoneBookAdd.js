import React, { useState, useEffect } from "react";
import { useHistory } from "react-router-dom";

const PhoneBookAdd = () => {
    const [name, setName] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [loading, setLoading] = useState(false);
    const [response, setResponse] = useState({});
    const history = useHistory();

    useEffect(() => {
        if (response && Object.keys(response).length > 0 && response.error === false) {
            history.push(`/`);
        }
    }, [response])

    const CreatePhoneBookEntry = async (e) => {
        e.preventDefault();

        if (name && name.length > 0 && phoneNumber && phoneNumber.length > 0) {
            setLoading(true);

            const response = await fetch(`/api/phonebook/addentry`,
                {
                    method: 'POST',
                    mode: 'cors',
                    cache: 'no-cache',
                    creddentials: 'same-origin',
                    redirect: 'follow',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ name: name, phoneNumber: phoneNumber })
                });
            const data = await response.json();
            setResponse(data);
            console.log(data);
            setLoading(false);
        }
    }

    return (
        <>
            <h1>Add Phone Book Entry</h1>
            <div className={"row"}>
                <div className={"col-md-6"}>
                    <div className={"form-group"}>
                        <label htmlFor="name">Name</label>
                        <input type="text" className={"form-control"} id="name" aria-describedby="nameHelp" placeholder="Enter Name" value={name} onChange={(e) => setName(e.target.value)} />
                    </div>
                    <div className={"form-group"}>
                        <label htmlFor="number">Phone Number</label>
                        <input type="text" className={"form-control"} id="number" placeholder="Phone number" value={phoneNumber} onChange={(e) => setPhoneNumber(e.target.value)} />
                    </div>
                    <button type="submit" className={"btn btn-primary"} onClick={(e) => CreatePhoneBookEntry(e)}>{loading?"Saving Data ...":"Create Entry"}</button>
                </div>
            </div>
            <div className={"row mt-2"}>
                <div className={"col-md-6"}>
                    {(response && Object.keys(response).length > 0 && response.error)?<div className={"alert alert-danger"} role={"alert"}>{response.errorMessage}</div>:null}
                </div>
            </div>

        </>
    )
}


export default PhoneBookAdd;

