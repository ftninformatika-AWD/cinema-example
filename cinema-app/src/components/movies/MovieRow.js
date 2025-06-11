import { useNavigate } from "react-router-dom";
import CinemaAxios from "../../apis/CinemaAxios";


const MovieRow = (props) => {

    var navigate = useNavigate()

    const goToEdit = (movieId) => {
        navigate('/movies/edit/' + movieId); 
    }

    const deleteMovie = (movieId) => {
        CinemaAxios.delete('/movies/' + movieId)
        .then(res => {
            // handle success
            console.log(res);
            alert('Movie was deleted successfully!');
            window.location.reload();
        })
        .catch(error => {
            // handle error
            console.log(error);
            alert('Error occured please try again!');
         });
    }

    return (
        <tr>
           <td>{props.movie.name}</td>
           <td>{props.movie.duration}</td>
           <td>{props.movie.genre.name}</td>
           <td><button className="button button-navy" onClick={() => goToEdit(props.movie.id)}>Edit</button></td>
           <td><button className="button button-navy" onClick={() => deleteMovie(props.movie.id)}>Delete</button></td>
        </tr>
     )
}

export default MovieRow;