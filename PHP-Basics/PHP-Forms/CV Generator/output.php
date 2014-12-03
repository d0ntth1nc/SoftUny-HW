<table>
    <thead>
        <tr>
            <th colspan="2">Personal Information</th>
        </tr>
    </thead>
    <tbody>
    <tr>
        <td>First Name</td>
        <td><?=$validator->getField("fname")?></td>
    </tr>
    <tr>
        <td>Last Name</td>
        <td><?=$validator->getField("lname")?></td>
    </tr>
    <tr>
        <td>Email</td>
        <td><?=$validator->getField("email")?></td>
    </tr>
    <tr>
        <td>Phone Number</td>
        <td><?=$validator->getField("phoneNumber")?></td>
    </tr>
    <tr>
        <td>Gender</td>
        <td><?=$validator->getField("sex")?></td>
    </tr>
    <tr>
        <td>Birth Date</td>
        <td><?=$validator->getField("birthDate")?></td>
    </tr>
    <tr>
        <td>Nationality</td>
        <td><?=$validator->getField("nationality")?></td>
    </tr>
    </tbody>
</table>

<table>
    <thead>
    <tr>
        <th colspan="2">Last Work Position</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>Company Name</td>
        <td><?=$validator->getField("companyName")?></td>
    </tr>
    <tr>
        <td>From</td>
        <td><?=$validator->getField("workFrom")?></td>
    </tr>
    <tr>
        <td>To</td>
        <td><?=$validator->getField("workTo")?></td>
    </tr>
    </tbody>
</table>

<table>
    <thead>
    <tr>
        <th colspan="2">Computer Skills</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>Programming Languages</td>
        <td>
            <table>
                <thead>
                <tr>
                    <th>Language</th>
                    <th>Skill Level</th>
                </tr>
                </thead>
                <tbody>
                <?php foreach($validator->getProgrammingLanguages() as $lang => $skillLevel) :?>
                <tr>
                    <td><?=$lang?></td>
                    <td><?=$skillLevel?></td>
                </tr>
                <?php endforeach; ?>
                </tbody>
            </table>
        </td>
    </tr>
    </tbody>
</table>

<table>
    <thead>
    <tr>
        <th colspan="2">Other Skills</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>Languages</td>
        <td>
            <table>
                <thead>
                <tr>
                    <th>Language</th>
                    <th>Comprehension</th>
                    <th>Reading</th>
                    <th>Writing</th>
                </tr>
                </thead>
                <tbody>
                <?php foreach($validator->getLanguages() as $lang => $values) :?>
                    <tr>
                        <td><?=$lang?></td>
                        <td><?=$values->comprehension?></td>
                        <td><?=$values->readingLevel?></td>
                        <td><?=$values->writingLevel?></td>
                    </tr>
                <?php endforeach; ?>
                </tbody>
            </table>
        </td>
    </tr>
    <tr>
        <td>Driver's license</td>
        <td><?=$validator->getDriverLicenses()?></td>
    </tr>
    </tbody>
</table>