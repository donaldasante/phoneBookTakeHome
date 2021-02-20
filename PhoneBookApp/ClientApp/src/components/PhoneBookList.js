import React, { useState, useEffect } from "react";
import Search from './Search'

const PhoneBookList = () => {

    const [phoneBookList, setPhoneBookList] = useState([]);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        populatePhoneData();
    }, []);


    const populatePhoneData = async () => {
        setLoading(true);
       const response = await fetch('/api/phonebook/getall');
       const data = await response.json();
       setPhoneBookList(data.payLoad);
        setLoading(false);
    }

    const renderPhoneList = () => {

        if (phoneBookList.length > 0) {
            return (
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Phone Number</th>
                        </tr>
                    </thead>
                    <tbody>
                        {phoneBookList.map((phoneBook, index) =>
                            <tr key={index}>
                                <td>{phoneBook.name}</td>
                                <td>{phoneBook.phoneNumber}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            )
        }
        else {
            return (
                <p><em>No phone book entries. Click Add Phone Entry Button...</em></p> 
            )
        }
    }

    const filterPhoneBook = async (searchParam) => {
        setLoading(true);
        const response = await fetch(`/api/phonebook/findentry?search=${searchParam}`);
        const data = await response.json();
        setPhoneBookList(data.payLoad);
        setLoading(false);
    }

    let contents = (loading) ? <p><em>Loading...</em></p> : renderPhoneList();

    return (
        <>
            <h1>Phone Book List</h1>
            <div>
                <Search filter={(searchParam) => filterPhoneBook(searchParam) }/>
            </div>
            <div>
                {contents}
            </div>
        </>
    )
}

export default PhoneBookList
