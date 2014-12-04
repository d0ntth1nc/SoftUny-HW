<?php
class StudentsSorter
{
    private $students = [];

    function __construct( $info )
    {
        if (isset( $info[ 'firstName' ], $info[ 'lastName' ],
            $info[ 'email' ], $info[ 'grade' ] )) {
            $studentsCount = count( $info[ 'firstName' ] );

            for ($i = 0; $i < $studentsCount; $i++) {
                $firstName = $info[ 'firstName' ][ $i ];
                $lastName = $info[ 'lastName' ][ $i ];
                $email = $info[ 'email' ][ $i ];
                $grade = $info[ 'grade' ][ $i ];
                if (empty( $firstName ) || empty( $lastName ) || empty( $email ) || !is_numeric( $grade )) {
                    $this->students = [];
                    break;
                }

                $this->students[] = [
                    'firstName' => $firstName,
                    'lastName' => $lastName,
                    'email' => $email,
                    'grade' => $grade
                ];
            }
        }
    }

    public function studentsCount()
    {
        return count( $this->students );
    }

    public function sort( $orderBy, $order )
    {
        usort( $this->students, function( $a, $b ) use ( $orderBy, $order )
        {
            $first = $a[ $orderBy ];
            $second = $b[ $orderBy ];
            if (is_numeric( $first ) && is_numeric( $second )) {
                return $order == 'ascending' ? $first - $second : $second - $first;
            } else {
                return $order == 'ascending' ? strcmp( $first, $second ) : strcmp( $second, $first );
            }
        });

        return $this->students;
    }
}