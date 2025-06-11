import React, { useEffect, useState } from 'react';
import CinemaAxios from '../../apis/CinemaAxios';
import { useNavigate } from 'react-router-dom'
import ScreeningRow from './ScreeningRow';

const Screenings = (props) => {

    const [screenings, setScreenings] = useState([])

    var navigate = useNavigate()

    const getScreenings = () => {
        CinemaAxios.get("/screenings")
            .then(res => {
                console.log(res)
                setScreenings(res.data)
            })
            .catch(error => {
                console.log(error)
            })
    }

    useEffect(() => {
        getScreenings()
    }, [])


    const goToAdd = () => {
        navigate("/screenings/add");
    }

    // todo: Ispisati naziv filma
    return (
        <div>
            <h1>Screenings</h1>

            <div>
                <button className="button button-navy" onClick={() => goToAdd()}>Add</button>
                <br />

                <table id="movies-table">
                    <thead>
                        <tr>
                            <th>Movie Name</th>
                            <th>Time</th>
                            <th>Screening Type</th>
                            <th>Hall</th>
                            <th>Price</th>
                        </tr>
                    </thead>
                    <tbody>
                        {screenings.map((screening) => {
                            return <ScreeningRow key={screening.id} screening={screening} editCallback={props.callback}></ScreeningRow>
                        })}
                    </tbody>
                </table>
            </div>
        </div>
    )
}

export default Screenings;