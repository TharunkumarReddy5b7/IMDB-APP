Feature: Actor Resource

@GetAllActors
Scenario: GetAll Actors
	Given I am a client
	When I make GET Request '<URL>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'
	Examples: 
	| URL        | ResponseCode | ResponseData                                                                                                                                                                    |
	| actors     | 200          | [{"id":1,"name":"Prabhas","bio":"Good Actor","dob":"12-12-1998 00:00:00","gender":"Male"},{"id":2,"name":"Rana","bio":"PowerStar","dob":"12-12-1998 00:00:00","gender":"Male"}] |

@GetActorById
Scenario Outline: Get Actor by ID
	Given I am a client
    When I make GET Request '<URL>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'

	@ValidCase
	Examples:
	| URL      | ResponseCode | ResponseData                                                                             |
	| actors/1 | 200          | {"id":1,"name":"Prabhas","bio":"Good Actor","dob":"12-12-1998 00:00:00","gender":"Male"} |
	| actors/2 | 200          | {"id":2,"name":"Rana","bio":"PowerStar","dob":"12-12-1998 00:00:00","gender":"Male"}     |
	
	@InvalidCase
	Examples:
	| URL       | ResponseCode | ResponseData               |
	| actors/20 | 404          | Actor with ID 20 not found |
	| actors/6  | 404          | Actor with ID 6 not found  |
	| actors/-1 | 404          | Invalid ActorId            |
	
@CreateActor
Scenario Outline: Create Actor
	Given I am a client
	When I am make POST Request '<URL>' with the following data '<RequestData>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'

	@ValidCase
	Examples:
	| URL    | RequestData                                                           | ResponseCode | ResponseData               |
	| actors | {"name":"Ntr","bio":"great actor","dob":"12/06/1992","gender":"Male"} | 201          | Actor successfully created |

	@InvalidCase
	Examples:
	| URL    | RequestData                                                                   | ResponseCode | ResponseData                |
	| actors | {"name":"","bio":"Fantstic actor","dob":"14/08/1976","gender":"Female"}       | 400          | Actor name can not be empty |
	| actors | {"name":"Prabhas","bio":"","dob":"19/08/1979","gender":"Male"}				 | 400          | Bio can not be empty        |
	| actors | {"name":"Prabhas","bio":"TollyWood Actor","dob":"date","gender":"Male"}       | 400          | Provide valid Dob           |
	| actors | {"name":"Prabhas","bio":"TollyWood Actor","dob":"19/08/1979","gender":""}	 | 400          | Gender can not be empty     |


@UpdateActor
Scenario Outline: Update Actor
	Given I am a client
	When  I make PUT Request '<URL>' with the following Data '<RequestData>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'

   @ValidCase
   Examples:
   | URL      | RequestData                                                              | ResponseCode | ResponseData               |
   | actors/1 | {"name":"NTR","bio":"Bulk Actor","dob":"19/08/1979","gender":"Male"}     | 200          | Actor Updated Successfully |

   @InvalidCase
   Examples:
   | URL       | RequestData                                                             | ResponseCode | ResponseData                |
   | actors/20 | {"name":"Tharun","bio":"Bulk Actor","dob":"19/08/1979","gender":"Male"} | 400          | Actor with Id 20 not found  |
   | actors/-1 | {"name":"Tharun","bio":"Bulk Actor","dob":"19/08/1979","gender":"Male"} | 400          | Invalid ActorId  |
   | actors/1  | {"name":"","bio":"Bulk Actor","dob":"19/08/1979","gender":"Male"}       | 400          | Actor name can not be empty |
   | actors/1  | {"name":"Nikhil","bio":"","dob":"19/08/1979","gender":"Male"}           | 400          | Bio can not be empty        |
   | actors/1  | {"name":"Nikhil","bio":"Bulk Actor","dob":"hhh","gender":"Male"}        | 400          | Provide valid Dob           |
   | actors/1  | {"name":"Nikhil","bio":"Bulk Actor","dob":"19/08/1979","gender":""}     | 400          | Gender can not be empty     |

@DeleteActor
Scenario Outline: Delete Actor
	Given I am a client
	When I make DELETE Request '<URL>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'

	@ValidCase
	Examples:
	| URL      | ResponseCode | ResponseData                |
	| actors/1 | 200          | Actor Deleted Succcessfully |
	| actors/2 | 200          | Actor Deleted Succcessfully |

	@InValidCase
	Examples:
	| URL       | ResponseCode | ResponseData                    |
	| actors/-1 | 400          | Invalid ActorId                 |
	| actors/13 | 400          | Actor with Id 13 does not found |



	


	



