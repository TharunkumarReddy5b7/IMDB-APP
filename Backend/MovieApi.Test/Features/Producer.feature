Feature: Producer Resource

@GetAllProducers
Scenario: GetAll Producers
	Given I am a client
	When I make GET Request '<URL>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'
	Examples: 
	| URL        | ResponseCode | ResponseData                                                                                                                                                                    |
	| producers    | 200          | [{"id":1,"name":"Shobu","bio":"Good Producer","dob":"12-12-1998 00:00:00","gender":"Male"},{"id":2,"name":"Viswak","bio":"Star Producer","dob":"12-12-1998 00:00:00","gender":"Male"}] |

@GetProducerById
Scenario Outline: Get Producer by ID
	Given I am a client
    When I make GET Request '<URL>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'

	@ValidCase
	Examples:
	| URL         | ResponseCode | ResponseData                                                                               |
	| producers/1 | 200          | {"id":1,"name":"Shobu","bio":"Good Producer","dob":"12-12-1998 00:00:00","gender":"Male"}  |
	| producers/2 | 200          | {"id":2,"name":"Viswak","bio":"Star Producer","dob":"12-12-1998 00:00:00","gender":"Male"} |
	
	@InvalidCase
	Examples:
	| URL          | ResponseCode | ResponseData                  |
	| producers/20 | 404          | Producer with Id 20 not found |
	| producers/6  | 404          | Producer with Id 6 not found  |
	| producers/-1 | 404          | Invalid ProducerId            |

@CreateProducer
Scenario Outline: Create Producer
	Given I am a client
	When I am make POST Request '<URL>' with the following data '<RequestData>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'

	@ValidCase
	Examples:
	| URL       | RequestData                                                                  | ResponseCode | ResponseData                  |
	| producers | {"name":"Danayya","bio":"Great Producer","dob":"12/06/1992","gender":"Male"} | 201          | Producer successfully created |

	@InvalidCase
	Examples:
	| URL       | RequestData                                                                | ResponseCode | ResponseData                   |
	| producers | {"name":"","bio":"Fantstic producer","dob":"14/08/1976","gender":"Female"} | 400          | Producer name can not be empty |
	| producers | {"name":"Kamal","bio":"","dob":"19/08/1979","gender":"Male"}               | 400          | Bio can not be empty           |
	| producers | {"name":"Kamal","bio":"TollyWood producer","dob":"date","gender":"Male"}   | 400          | Provide valid Dob              |
	| producers | {"name":"Kamal","bio":"TollyWood producer","dob":"19/08/1979","gender":""} | 400          | Gender can not be empty        |

@UpdateProducer
Scenario Outline: Update Producer
	Given I am a client
	When  I make PUT Request '<URL>' with the following Data '<RequestData>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'

   @ValidCase
   Examples:
   | URL         | RequestData                                                                    | ResponseCode | ResponseData                  |
   | producers/1 | {"name":"Arjun","bio":"Bollywood Producer","dob":"19/08/1979","gender":"Male"} | 200          | Producer updated successfully |

   @InvalidCase
   Examples:
   | URL          | RequestData                                                                | ResponseCode | ResponseData                   |
   | producers/20 | {"name":"Tharun","bio":"Nice Producer","dob":"19/08/1979","gender":"Male"} | 400          | Producer with Id 20 not found  |
   | producers/-1 | {"name":"Tharun","bio":"Nice Producer","dob":"19/08/1979","gender":"Male"} | 400          | Invalid ProducerId  |
   | producers/1  | {"name":"","bio":"Nice Producer","dob":"19/08/1979","gender":"Male"}       | 400          | Producer name can not be empty |
   | producers/1  | {"name":"Nikhil","bio":"","dob":"19/08/1979","gender":"Male"}              | 400          | Bio can not be empty           |
   | producers/1  | {"name":"Nikhil","bio":"Nice Producer","dob":"hhh","gender":"Male"}        | 400          | Provide valid Dob              |
   | producers/1  | {"name":"Nikhil","bio":"Nice Producer","dob":"19/08/1979","gender":""}     | 400          | Gender can not be empty        |

@DeleteProducer
Scenario Outline: Delete Producer
	Given I am a client
	When I make DELETE Request '<URL>'
	Then response code must be '<ResponseCode>'
	And response data must look like '<ResponseData>'

	@ValidCase
	Examples:
	| URL         | ResponseCode | ResponseData                   |
	| producers/1 | 200          | Producer Deleted Succcessfully |
	| producers/2 | 200          | Producer Deleted Succcessfully |

	@InValidCase
	Examples:
	| URL          | ResponseCode | ResponseData                       |
	| producers/-1 | 400          | Invalid ProducerId                 |
	| producers/13 | 400          | Producer with Id 13 does not found |




	