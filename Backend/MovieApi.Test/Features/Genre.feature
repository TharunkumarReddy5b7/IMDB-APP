Feature: Genre Resource

@GetAllGenres
Scenario: GetAll Genres
	Given I am a client
	When I make GET Request '<URL>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'
	Examples: 
	| URL    | ResponseCode | ResponseData                                       |  
	| genres | 200          | [{"id":1,"name":"Action"},{"id":2,"name":"Drama"}] |

@GetGenreById
Scenario Outline: Get Genre by ID
	Given I am a client
    When I make GET Request '<URL>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'

	@ValidCase
	Examples:
	| URL      | ResponseCode | ResponseData             |
	| genres/1 | 200          | {"id":1,"name":"Action"} |
	| genres/2 | 200          | {"id":2,"name":"Drama"}  |
	
	@InvalidCase
	Examples:
	| URL       | ResponseCode | ResponseData               |
	| genres/20 | 404          | Genre with Id 20 not found |
	| genres/6  | 404          | Genre with Id 6 not found  |
	| genres/-1 | 404          | Invalid GenreId            |

@CreateGenre
Scenario Outline: Create Genre
	Given I am a client
	When I am make POST Request '<URL>' with the following data '<RequestData>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'

	@ValidCase
	Examples:
	| URL    | RequestData       | ResponseCode | ResponseData               |
	| genres | {"name":"Comedy"} | 201          | Genre successfully created |

	@InvalidCase
	Examples:
	| URL    | RequestData | ResponseCode | ResponseData                |
	| genres | {"name":""} | 400          | Genre name can not be empty |


@UpdateGenre
Scenario Outline: Update Genre
	Given I am a client
	When  I make PUT Request '<URL>' with the following Data '<RequestData>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'

   @ValidCase
   Examples:
   | URL      | RequestData       | ResponseCode | ResponseData               |
   | genres/1 | {"name":"Horror"} | 200          | Genre Updated Successfully |

   @InvalidCase
   Examples:
   | URL       | RequestData        | ResponseCode | ResponseData                |
   | genres/11 | {"name":"Emotion"} | 400          | Genre with Id 11 not found  |
   | genres/-1 | {"name":"Emotion"} | 400          | Invalid GenreId             |
   | genres/1  | {"name":"" }       | 400          | Genre name can not be empty |
   
@DeleteGenre
Scenario Outline: Delete Genre
	Given I am a client
	When I make DELETE Request '<URL>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'

	@ValidCase
	Examples:
	| URL      | ResponseCode | ResponseData               |
	| genres/1 | 200          | Genre Deleted Successfully |
	| genres/2 | 200          | Genre Deleted Successfully |

	@InValidCase
	Examples:
	| URL       | ResponseCode | ResponseData               |
	| genres/13 | 400          | Genre with Id 13 not found |
	| genres/-1 | 400          | Invalid GenreId            |


