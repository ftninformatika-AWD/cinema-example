import { useEffect, useState } from "react"
import { useNavigate } from "react-router-dom"
import CinemaAxios from "../../apis/CinemaAxios"

const EditScreening = (props) => {

    // Convert to local time string for input
    const formatDate = dateAsString => {
        const date = new Date(dateAsString);
        return new Date(date.getTime() - date.getTimezoneOffset() * 60000)
            .toISOString()
            .slice(0, 16);  // 'YYYY-MM-DDTHH:MM'
    }

    const [screening, setScreening] = useState({
        id: props.selectedScreening.id,
        time: formatDate(props.selectedScreening.scheduledAt),
        type: props.selectedScreening.screeningType,
        hall: props.selectedScreening.room,
        price: props.selectedScreening.ticketPrice,
        movie: props.selectedScreening.movieId
    });

    const navigate = useNavigate()

    const [movies, setMovies] = useState([])

    useEffect(() => {
        const getMovies = () => {
            CinemaAxios.get('/movies')
                .then(res => {
                    // handle success
                    setMovies(res.data);
                })
                .catch(error => {
                    // handle error
                    console.log(error);
                    alert('Error occured please try again!');
                });
        }

        getMovies()
    }, [])

    const onInputChange = event => {
        const { name, value } = event.target;

        setScreening((screening) => {
            var new_screening = { ...screening }
            new_screening[name] = value
            return new_screening
        });
    }

    const edit = () => {
        const params = {
            id: screening.id,
            scheduledAt: (new Date(screening.time)).toISOString(),
            movieId: screening.movie,
            room: screening.hall,
            screeningType: screening.type,
            ticketPrice: screening.price
        };

        CinemaAxios.put('/screenings/' + screening.id, params)
            .then(res => {
                alert('Screening was edited successfully!');
                navigate('/screenings');
            })
            .catch(error => {
                console.log(error);
                alert('Error occured please try again!');
            });
    }

    return (
        <div>
            <h1>Edit Screening</h1>

            <label htmlFor="pTime">Time</label>
            <input id="pTime" name="time" type="datetime-local" value={screening.time} onChange={(e) => onInputChange(e)} /> <br />
            <label htmlFor="pType">Type</label>
            <input id="pType" name="type" value={screening.type} onChange={(e) => onInputChange(e)} /> <br />
            <label id="pHall">Hall</label>
            <input type="number" id="pHall" name="hall" value={screening.hall} onChange={(e) => onInputChange(e)} /> <br />
            <label htmlFor="pPrice">Price</label>
            <input type="number" step=".01" id="pPrice" name="price" value={screening.price} onChange={(e) => onInputChange(e)} /> <br />
            <label htmlFor="pMovie">Movies</label>
            <select id="pMovie" value={screening.movie} onChange={event => onInputChange(event)}>
                {
                    movies.map((movie) => {
                        return (
                            <option key={movie.id} value={movie.id}>{movie.name}</option>
                        )
                    })
                }
            </select>
            <br />
            <button onClick={() => { edit() }}>Edit</button>
        </div>
    );
}

export default EditScreening
