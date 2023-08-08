Feature: Movie Resource

@GetAllMovies
Scenario: GetAll Movies
	Given I am a client
	When I make GET Request '<URL>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'
	Examples: 
	| URL    | ResponseCode | ResponseData                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
	| movies | 200          | [{"id":1,"name":"RRR","yearOfRelease":2018,"plot":"Story Movie","actors":[{"id":1,"name":"Prabhas","bio":"Good Actor","dob":"12-12-1998 00:00:00","gender":"Male"},{"id":2,"name":"Rana","bio":"PowerStar","dob":"12-12-1998 00:00:00","gender":"Male"}],"genres":[{"id":1,"name":"Action"}],"coverImage":"Link","producer":{"id":1,"name":"Shobu","bio":"Good Producer","dob":"12-12-1998 00:00:00","gender":"Male"}},{"id":2,"name":"Robo","yearOfRelease":2019,"plot":"Technical Movie","actors":[{"id":1,"name":"Prabhas","bio":"Good Actor","dob":"12-12-1998 00:00:00","gender":"Male"},{"id":2,"name":"Rana","bio":"PowerStar","dob":"12-12-1998 00:00:00","gender":"Male"}],"genres":[{"id":2,"name":"Drama"}],"coverImage":"Link","producer":{"id":1,"name":"Shobu","bio":"Good Producer","dob":"12-12-1998 00:00:00","gender":"Male"}}] |

@GetMovieById
Scenario Outline: Get Movie By Id
	Given I am a client
	When I make GET Request '<URL>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'

	@ValidCase
	Examples: 
	| URL      | ResponseCode | ResponseData                                                                                                                                                                                                                                                                                                                                                                                                               |
	| movies/1 | 200          | {"id":1,"name":"RRR","yearOfRelease":2018,"plot":"Story Movie","actors":[{"id":1,"name":"Prabhas","bio":"Good Actor","dob":"12-12-1998 00:00:00","gender":"Male"},{"id":2,"name":"Rana","bio":"PowerStar","dob":"12-12-1998 00:00:00","gender":"Male"}],"genres":[{"id":1,"name":"Action"}],"coverImage":"Link","producer":{"id":1,"name":"Shobu","bio":"Good Producer","dob":"12-12-1998 00:00:00","gender":"Male"}}      |
	| movies/2 | 200          | {"id":2,"name":"Robo","yearOfRelease":2019,"plot":"Technical Movie","actors":[{"id":1,"name":"Prabhas","bio":"Good Actor","dob":"12-12-1998 00:00:00","gender":"Male"},{"id":2,"name":"Rana","bio":"PowerStar","dob":"12-12-1998 00:00:00","gender":"Male"}],"genres":[{"id":2,"name":"Drama"}],"coverImage":"Link","producer":{"id":1,"name":"Shobu","bio":"Good Producer","dob":"12-12-1998 00:00:00","gender":"Male"}} |

	@InvalidCase
	Examples:
	| URL       | ResponseCode | ResponseData               |
	| movies/20 | 404          | Movie with Id 20 not found |
	| movies/-1 | 404          | Invalid MovieId            |

@CreateMovie
Scenario Outline: Create Movie
	Given I am a client
	When I am make POST Request '<URL>' with the following data '<RequestData>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'

	@ValidCase
	Examples:
	| URL    | RequestData                                                                                                                  | ResponseCode | ResponseData               |
	| movies | {"name":"Bahubali","YearOfRelease":2009,"Plot":"Epic Movie","ProducerId":2,"Actorids":[2],"CoverImage":"url","Genreids":[1]} | 201          | Movie successfully created |

	@InvalidCase
	Examples:
	| URL    | RequestData                                                                                                                 | ResponseCode | ResponseData                        |
	| movies | {"name":"","YearOfRelease":2009,"Plot":"Epic Movie","ProducerId":2,"Actorids":[2],"CoverImage":"url","Genreids":[1]}        | 400          | Movie name can not be null or empty |
	| movies | {"name":"Bahubali","YearOfRelease":0,"Plot":"Epic Movie","ProducerId":2,"Actorids":[2],"CoverImage":"url","Genreids":[1]}   | 400          | Enter valid year                    |
	| movies | {"name":"Bahubali","YearOfRelease":2009,"Plot":"","ProducerId":2,"Actorids":[2],"CoverImage":"url","Genreids":[1]}          | 400          | Plot can not be empty               |
	| movies | {"name":"Bahubali","YearOfRelease":2009,"Plot":"Epic Movie","ProducerId":2,"Actorids":[],"CoverImage":"url","Genreids":[1]} | 400          | please enter atleast one actorid    |
	| movies | {"name":"Bahubali","YearOfRelease":2009,"Plot":"Epic Movie","ProducerId":2,"Actorids":[2],"CoverImage":"url","Genreids":[]} | 400          | please enter atleast one Genreid    |
	| movies | {"name":"Bahubali","YearOfRelease":2009,"Plot":"Epic Movie","ProducerId":2,"Actorids":[2],"CoverImage":"","Genreids":[1]}   | 400          | cover image cannot be empty          |

@UpdateMovie
Scenario Outline: Update Movie
	Given I am a client
	When  I make PUT Request '<URL>' with the following Data '<RequestData>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'

	@ValidCase
	Examples:
	| URL      | RequestData                                                                                                                  | ResponseCode | ResponseData               |
	| movies/1 | {"name":"Bahubali","YearOfRelease":2009,"Plot":"Epic Movie","ProducerId":2,"Actorids":[2],"CoverImage":"url","Genreids":[1]} | 200          | Movie updated successfully |

	@InvalidCase
	Examples:
	| URL       | RequestData                                                                                                                  | ResponseCode | ResponseData                        |
	| movies/1  | {"name":"","YearOfRelease":2009,"Plot":"Epic Movie","ProducerId":2,"Actorids":[2],"CoverImage":"url","Genreids":[1]}         | 400          | Movie name can not be null or empty |
	| movies/1  | {"name":"Bahubali","YearOfRelease":0,"Plot":"Epic Movie","ProducerId":2,"Actorids":[2],"CoverImage":"url","Genreids":[1]}    | 400          | Enter valid year                    |
	| movies/1  | {"name":"Bahubali","YearOfRelease":2009,"Plot":"","ProducerId":2,"Actorids":[2],"CoverImage":"url","Genreids":[1]}           | 400          | Plot can not be empty               |
	| movies/1  | {"name":"Bahubali","YearOfRelease":2009,"Plot":"Epic Movie","ProducerId":2,"Actorids":[],"CoverImage":"url","Genreids":[1]}  | 400          | please enter atleast one actorid    |
	| movies/1  | {"name":"Bahubali","YearOfRelease":2009,"Plot":"Epic Movie","ProducerId":2,"Actorids":[2],"CoverImage":"url","Genreids":[]}  | 400          | please enter atleast one Genreid    |
	| movies/1  | {"name":"Bahubali","YearOfRelease":2009,"Plot":"Epic Movie","ProducerId":2,"Actorids":[2],"CoverImage":"","Genreids":[1]}    | 400          | cover image cannot be empty         |
	| movies/20 | {"name":"Bahubali","YearOfRelease":2009,"Plot":"Epic Movie","ProducerId":2,"Actorids":[2],"CoverImage":"url","Genreids":[1]} | 400          | Movie with Id 20 not found          |
	| movies/-1 | {"name":"Bahubali","YearOfRelease":2009,"Plot":"Epic Movie","ProducerId":2,"Actorids":[2],"CoverImage":"url","Genreids":[1]} | 400          | Invalid MovieId                     |


@DeleteMovie
Scenario Outline: Delete Movie
	Given I am a client
	When I make DELETE Request '<URL>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'

	@ValidCase
	Examples:
	| URL      | ResponseCode | ResponseData               |
	| movies/1 | 200          | Movie Deleted Successfully |
	| movies/2 | 200          | Movie Deleted Successfully |


	@InvalidCase
	Examples:
	| URL       | ResponseCode | ResponseData               |
	| movies/-1 | 400          | Invalid MovieId            |
	| movies/34 | 400          | Movie with Id 34 not found |

	



